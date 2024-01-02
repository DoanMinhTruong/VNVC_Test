from rest_framework import viewsets
from django.shortcuts import get_object_or_404
from .models import JackPot
from user.models import User
from .serializers import JackPotSerializer, JackPotSerializerWithUser
from rest_framework.decorators import api_view
from rest_framework.response import Response
from django.db.models import Count
from django.core import serializers
from django.http import JsonResponse
from jackpot.models import ResultNumber
from rest_framework import status
from rest_framework.views import APIView
from django.core.exceptions import ValidationError
from datetime import datetime

class JackPotListCreateView(APIView):
    def get(self, request):
        jackpots = JackPot.objects.all()
        serializer = JackPotSerializer(jackpots, many=True)
        return Response(serializer.data)

    def post(self, request):
        serializer = JackPotSerializer(data=request.data)
        if serializer.is_valid():
            slot = serializer.validated_data['slot']
            user = serializer.validated_data['user']
            created = datetime.now().date()
            existing_jackpot = JackPot.objects.filter(user = user , slot=slot, created=created).exists()
            if existing_jackpot:
                raise ValidationError("A JackPot with the same slot already exists for this date.")
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)


@api_view(['GET'])
def jackpot_by_size(request, size):
    jackpot = JackPot.objects.order_by('created')[:size]
    serializer = JackPotSerializerWithUser(jackpot , many=True)
    return Response(serializer.data)


@api_view(['GET'])
def jackpot_by_phone_number(request, phone_number):
    user = get_object_or_404(User , phone_number = phone_number)
    jackpot = JackPot.objects.filter(user = user)
    serializer = JackPotSerializer(jackpot , many=True)
    return Response(serializer.data)

@api_view(['GET'])
def user_stats_by_number(request):
    user_stats = JackPot.objects.values('user', 'number').annotate(count=Count('number'))
    return Response(user_stats)

@api_view(['GET'])
def number_stats(request):
    number_stats = JackPot.objects.filter(number__range=(0, 9)).values('number').annotate(count=Count('number'))
    return Response(number_stats)

@api_view(['GET'])
def number_stats_win(request):
    number_stats = JackPot.objects.filter(number__range=(0, 9) , status = 1).values('number').annotate(count=Count('number'))
    return Response(number_stats)

@api_view(['GET'])
def current_result_number(request):
    result_number = ResultNumber.objects.latest('pk')
    return Response({"current_number" : result_number.number} )