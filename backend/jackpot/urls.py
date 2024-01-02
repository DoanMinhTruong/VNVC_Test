from django.urls import path
from .views import *

urlpatterns = [
    path('', JackPotListCreateView.as_view(), name='jackpots'),
    path('phone_number/<str:phone_number>/', jackpot_by_phone_number, name = 'jackpot_by_phone_number'),
    path('stats/user_stats_by_number/' , user_stats_by_number , name = 'user_stats_by_number'),
    path('stats/number_stats/', number_stats , name = 'number_stats'), 
    path('stats/number_stats_win/' , number_stats_win , name = "number_stats_win"),
    path('current_result_number/', current_result_number , name = 'current_result_number'), 
    path('size/<int:size>/' , jackpot_by_size , name= "jackpot_by_size"),

]