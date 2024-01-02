from django.db import models
from user.models import User
from django.core.validators import MaxValueValidator, MinValueValidator
# Create your models here.
class JackPot(models.Model):
    user = models.ForeignKey(User,  on_delete = models.CASCADE)
    number = models.IntegerField(validators=[MaxValueValidator(9), MinValueValidator(0)] , blank = False, null = False)
    slot = models.IntegerField(blank = False,  null = False)
    created = models.DateField(auto_now_add=True)
    status = models.IntegerField(choices = (
        (0 , 'Pending') , (1 , 'Win') , (2 , 'Lose')
    ), default = 0 )

    def __str__(self):
        return str(self.user) + " | " + str(self.number) + " | " + str(self.created) + " | " + str(self.status)



class ResultNumber(models.Model):
    number = models.IntegerField(validators=[MaxValueValidator(9), MinValueValidator(0)] , blank = False, null = False)
    created = models.DateTimeField(auto_now_add=True)
    def __str__(self):
        return str(self.number) + " | " + str(self.created)
    
