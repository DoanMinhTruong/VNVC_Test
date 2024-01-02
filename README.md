# VNVC Test - Xổ Số Kiến Thiết Con Gà Trống

### Author: Doan Minh Truong
GitHub: [https://github.com/DoanMinhTruong](https://github.com/DoanMinhTruong)

## Introduction
The Con Gà Trống lottery company has an interesting lottery rule. Every hour, the company will draw a random number and open a slot, with the result being an integer between 0 and 9. For example, at 5:00 AM, the result of the draw could be 3; at 6:00 AM, it could be 2; and at 9:00 PM, it could be 7.

At any given time, each player can place a purchase for a number within a time range of 1 minute to 60 minutes after the current slot. For example, at 5:25 PM, a player can place a purchase for the slot at 6:00 PM, but not for any slots before or after that time. At 7:00 PM, a player can place a purchase for the slot at 8:00 PM, but not for any slots before or after that time.

## Running the App

### Backend:
1. Activate the virtual environment:
   - For Windows: `.\backend\env\Scripts\activate`
   - For Linux: `source ./backend/env/bin/activate`

2. Install the required libraries:
   ````
   pip install -r ./backend/requirements.txt
   ```

3. Run the local server (make sure Port 8000 is not in use):
   ````
   python manage.py runserver --noreload
   ```

### C# Client:
1. Open the "VNVC_Jackpot/VNVC_Jackpot.sln" file using Visual Studio IDE.

2. Click on the "Run" button to start the client application.

## Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, please feel free to create a pull request or submit an issue on the [GitHub repository](https://github.com/DoanMinhTruong/VNVC_Test).

