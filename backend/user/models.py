from django.db import models
from django.contrib.auth.models import AbstractBaseUser, BaseUserManager

class UserManager(BaseUserManager):
    def create_user(self, phone_number, name, birth_date):
        if not phone_number:
            raise ValueError('Phone number is required')
        if not name:
            raise ValueError('Name is required')
        if not birth_date:
            raise ValueError('Birth date is required')

        user = self.model(
            phone_number=phone_number,
            name=name,
            birth_date=birth_date,
        )
        user.save(using=self._db)
        return user

    def create_superuser(self, phone_number, name, birth_date, password=None):
        user = self.create_user(
            phone_number=phone_number,
            name=name,
            birth_date=birth_date,
        )
        user.is_admin = True
        user.is_staff = True

        user.set_password(password)  # Set the provided password
        user.save(using=self._db)
        return user

class User(AbstractBaseUser):
    phone_number = models.CharField(max_length=20, unique=True)
    name = models.CharField(max_length=255)
    birth_date = models.DateField()
    is_active = models.BooleanField(default=True)
    is_admin = models.BooleanField(default=False)
    is_staff = models.BooleanField(default=False)
    objects = UserManager()

    USERNAME_FIELD = 'phone_number'
    REQUIRED_FIELDS = ['name', 'birth_date']

    def __str__(self):
        return self.phone_number + " | " + self.name + " | " + str(self.birth_date )

    def has_perm(self, perm, obj=None):
        return self.is_admin

    def has_module_perms(self, app_label):
        return self.is_admin