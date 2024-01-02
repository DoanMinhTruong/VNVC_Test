# VNVC Test - Xổ Số Kiến Thiết Con Gà Trống

### Author: Doan Minh Truong
GitHub: [https://github.com/DoanMinhTruong](https://github.com/DoanMinhTruong)

## Introduction
The Con Gà Trống lottery company has an interesting lottery rule. Every hour, the company will draw a random number and open a slot, with the result being an integer between 0 and 9. For example, at 5:00 AM, the result of the draw could be 3; at 6:00 AM, it could be 2; and at 9:00 PM, it could be 7.

At any given time, each player can place a purchase for a number within a time range of 1 minute to 60 minutes after the current slot. For example, at 5:25 PM, a player can place a purchase for the slot at 6:00 PM, but not for any slots before or after that time. At 7:00 PM, a player can place a purchase for the slot at 8:00 PM, but not for any slots before or after that time.

## Running the App

### Backend:
The backend of this project is developed using Python and Django framework. Therefore, please make sure that you have Python installed before proceeding with the setup.

#### Python Installation
1. Visit the official Python website at [python.org](https://www.python.org).
2. Download the latest stable version of Python for your operating system.
3. Run the installer and follow the instructions to install Python.
4. Once the installation is complete, open a new terminal or command prompt and verify the installation by running the following command:
   ````
   python --version
   ```
This should display the installed Python version.

#### Setting up the Backend Environment
1. Install the required libraries:
   ````
   pip install -r ./backend/requirements.txt
   ```

2. Run the local server (make sure Port 8000 is not in use):
   ````
   python manage.py runserver --noreload
   ```
3. The server should now be running on http://localhost:8000. You can access the backend API endpoints from this URL.

### C# Client:
1. Open the "VNVC_Jackpot/VNVC_Jackpot.sln" file using Visual Studio IDE.

2. Click on the "Run" button to start the client application.

## Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, please feel free to create a pull request or submit an issue on the [GitHub repository](https://github.com/DoanMinhTruong/VNVC_Test).





