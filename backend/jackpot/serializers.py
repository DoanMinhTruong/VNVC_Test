from rest_framework import serializers
from .models import JackPot, ResultNumber
from user.serializers import UserSerializer
class JackPotSerializer(serializers.ModelSerializer):
    class Meta:
        model = JackPot
        fields = '__all__'

class JackPotSerializerWithUser(serializers.ModelSerializer):
    user = UserSerializer()
    class Meta:
        model = JackPot
        fields = '__all__'

class ResultNumber(serializers.ModelSerializer):
    class Meta:
        model = ResultNumber
        fields = '__all__'