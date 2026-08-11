# 🏢 RFID Personnel Tracking System (PDKS)

An automated, smart Personnel Attendance Control System built with C# Windows Forms, SQLite, and Arduino RFID integration. 

## 🚀 Features
* **Smart Entry/Exit Algorithm:** The system checks the employee's last status. If they are in, scanning the card logs an "Exit" (Orange). If they are out, it logs an "Entry" (Green).
* **Ghost Read Protection:** Engineered serial port reading with try-catch blocks and BytesToRead verification to prevent application crashes from empty or phantom serial data.
* **Database Constraints:** UNIQUE constraints on RFID cards prevent the same card from being assigned to multiple employees.
* **Local Database:** Fully portable `SQLite` database integration requiring no external SQL Server installations.
* **Live Dashboard:** Real-time logging of scanned cards with timestamp tracking.

## 🛠️ Technologies Used
* **Language:** C# (.NET Framework)
* **UI:** Windows Forms
* **Database:** SQLite
* **Hardware Integration:** System.IO.Ports (Serial Port communication)
* **Hardware:** Arduino Uno & RC522 RFID Module

## 📸 Screenshots
*(Buraya programının çalışan halinden 1-2 tane ekran görüntüsü eklemelisin. GitHub'da Issues veya README düzenleme ekranına fotoğrafı sürükleyip bırakarak linkini buraya yapıştırabilirsin.)*

## ⚙️ Setup & Installation
1. Download the latest release from the [Releases](../../releases) tab.
2. Extract the ZIP file.
3. Run `personel_takip_sefa_can_celik.exe` (The SQLite `.db` file and required `.dll` files must remain in the same folder).
4. Select your Arduino's COM Port from the dashboard and click "Connect".
