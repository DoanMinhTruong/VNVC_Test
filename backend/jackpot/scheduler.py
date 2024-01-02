from backend.background import BackgroundSingleton



from jackpot.models import ResultNumber, JackPot
import random

def result():
    rnb = random.randint(0, 9)
    rs = ResultNumber(number = rnb)
    rs.save()
    jps = JackPot.objects.filter(status = 0)
    for jp in jps:
        if(jp.number == rnb):
            jp.status = 1
        else:
            jp.status = 2
        jp.save()

    print("done")
    
def start():
    background_singleton = BackgroundSingleton()
    background_singleton.add_job(result , 'cron', hour='0-23', minute='0', second='0')
    background_singleton.start()



