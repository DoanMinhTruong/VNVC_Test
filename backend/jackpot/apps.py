from django.apps import AppConfig


class JackpotConfig(AppConfig):
    default_auto_field = 'django.db.models.BigAutoField'
    name = 'jackpot'
    def ready(self):
        from . import scheduler
        scheduler.start()
        