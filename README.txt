#___██╗_██████╗███████╗_____██████╗██████╗_███████╗_█████╗_███╗___███╗______________________________
#___██║██╔════╝██╔════╝____██╔════╝██╔══██╗██╔════╝██╔══██╗████╗_████║______________________________
#___██║██║_____█████╗______██║_____██████╔╝█████╗__███████║██╔████╔██║______________________________
#___██║██║_____██╔══╝______██║_____██╔══██╗██╔══╝__██╔══██║██║╚██╔╝██║______________________________
#___██║╚██████╗███████╗____╚██████╗██║__██║███████╗██║__██║██║_╚═╝_██║______________________________
#___╚═╝_╚═════╝╚══════╝_____╚═════╝╚═╝__╚═╝╚══════╝╚═╝__╚═╝╚═╝_____╚═╝______________________________
#___██╗███╗___██╗██╗___██╗███████╗███╗___██╗████████╗_██████╗_██████╗_██╗___██╗_____________________
#___██║████╗__██║██║___██║██╔════╝████╗__██║╚══██╔══╝██╔═══██╗██╔══██╗╚██╗_██╔╝_____________________
#___██║██╔██╗_██║██║___██║█████╗__██╔██╗_██║___██║___██║___██║██████╔╝_╚████╔╝______________________
#___██║██║╚██╗██║╚██╗_██╔╝██╔══╝__██║╚██╗██║___██║___██║___██║██╔══██╗__╚██╔╝_______________________
#___██║██║_╚████║_╚████╔╝_███████╗██║_╚████║___██║___╚██████╔╝██║__██║___██║________________________
#___╚═╝╚═╝__╚═══╝__╚═══╝__╚══════╝╚═╝__╚═══╝___╚═╝____╚═════╝_╚═╝__╚═╝___╚═╝________________________
#___███╗___███╗_█████╗_███╗___██╗_█████╗__██████╗_███████╗███╗___███╗███████╗███╗___██╗████████╗____
#___████╗_████║██╔══██╗████╗__██║██╔══██╗██╔════╝_██╔════╝████╗_████║██╔════╝████╗__██║╚══██╔══╝____
#___██╔████╔██║███████║██╔██╗_██║███████║██║__███╗█████╗__██╔████╔██║█████╗__██╔██╗_██║___██║_______
#___██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║___██║██╔══╝__██║╚██╔╝██║██╔══╝__██║╚██╗██║___██║_______
#___██║_╚═╝_██║██║__██║██║_╚████║██║__██║╚██████╔╝███████╗██║_╚═╝_██║███████╗██║_╚████║___██║_______
#___╚═╝_____╚═╝╚═╝__╚═╝╚═╝__╚═══╝╚═╝__╚═╝_╚═════╝_╚══════╝╚═╝_____╚═╝╚══════╝╚═╝__╚═══╝___╚═╝_______
#___________________________________________________________________________________________________
#_____________________________________Winter Water Interactive______________________________________
#_______________________________Copyright © 2016 All Rights Reserved________________________________

MANUAL

Contents
	0. Some Classic README Ascii Art
	1. System Requirements
		Minimum
		Recommended
	2. Warnings
	3. Assumptions
	4. Instructions
		Basic Functionality
		Text Message Notifications
	5. File Types
		City Upload File
		Route Upload File
		Truck Upload File
		Driver Upload File
		Daily Inventory File
		Load Truck Route Driver File
		Load Ice Cream Truck Inventory File
		Customer Request File
		Sales File
	6. Program State
	
System Requirements
Minimum: 
	OS: Windows 7
	Processor: Intel® Core™ 2 Duo E6600 or AMD Phenom™ X3 8750 processor or better
	Memory: 4 GB RAM
	Graphics: 246 MB or more. DirectX 9-compatible
	DirectX: Version 9.0c
	Storage: 200 MB available space
Recommended: 
	OS: Windows 7/8/10
	Processor: Intel Core i7-3770K or better
	Memory: 16 GB RAM
	Graphics: NVIDIA GeForce GTX 980ti or AMD Radeon R9 390X or better (4 GB VRAM)
	DirectX: Version 11
	Network: Gigabit Internet Connection
	Storage: 1 GB available space
	Internet Connection And Phone For Notification Service

Warnings
* DO NOT Delete Database Files. This Will Delete All Data In The Software. The Software Will Run As A First Time Setup.
* DO NOT Delete .exe Or DLL Files. This Will Remove The Software From Your Computer. The Software Will Not Run.
* File Processing Is Character Sensitive. Data Must Fit All Spaces Exactly.
* Files Must Be Submitted In The Correct Order. Instructions Below. 
* Route, Truck, Driver, And Item Numbers MUST NOT BE ZERO. This May Cause Errors In The Software.
* File Names DO NOT Have To Follow The File Names Below. It Is Suggested For The User.

Assumptions
* Must Have An Internet Connection For Text Message Notifications.
* Must Have An Active And Valid Phone Number For Text Message Notifications.
* Must Select The Correct Carrier For Text Message Notifications.

Instructions
	Basic Functionality 
	1. Place files in a safe directory that you will access within the program. 
	2. Make sure file names and the data in them are correct. Example files and names shown below. 
	
	If this is not your first time running and there is data in the program, skip to Step 7 for the normal day cycle.
		3. Browse and upload City Upload File: cityUpload.txt
		4. Browse and upload Route Upload File: routeUpload.txt
		5. Browse and upload Truck Upload File: truckUpload.txt
		6. Browse and upload Driver Upload File: driverUpload.txt
		7*. Set the Default Truck Inventory by clicking "Set Default Inventory" on the "Files" screen.
		8*. Enter the Product ID and Quantities for 5 items. Click "Set Default".
		
	9. Browse and upload Inventory Update File: dailyInventory.txt
	10. Browse and upload Truck Route Driver File: truckRouteDriver.txt
	11. Click "Load Ice cream to Trucks".
	12. Click "Send out Trucks". 
	13. Once it's the end of the day and the trucks are back,
	    	Browse and upload Calculate Sales of Day File: dailySales.txt
	14. Click "End Day".
	12. now the sequence is complete and you can view data by clicking on any tab. 
	
	*Steps 7 and 8 can also be completed by clicking the browse button next to "Change Truck Inventory". 
		Browse and upload Load Ice Cream Truck Inventory File: loadTruck.txt
	
	Text Message Notifications
	1. Click "Settings" on the "Files" screen.
	2. Check any notifications you'd like to receive. Uncheck any notifications you'd not like to receive.
	3. Enter a valid and active 10 digit phone number in the "Phone Number" box. 
	   	Do not include the country code. 
	4. Select a "Carrier" from the drop down menu.
	5. Click "Save Settings".
	
File Types
	The Program Accepts Several Different Files. They All Vary By Name And Data. Certain Files Are Required Daily And Certain Files Are Optional.
	
	City Upload File (FIRST TIME SETUP / ON DEMAND)
		File: cityUpload.txt
		Initial Header Sequence: 0102
		
		Format: 
		HD SEQ#      YYYY-MM-DD 
		|------city label----||------city name-----||state|
		T #ROWS
		
		Example:
		HD 0103      2016-03-01
		Dearborn 1          Dearborn            MI
		Dearborn 2          Dearborn            MI
		Dearborn 3          Dearborn            MI
		T 0003  
		
	Route Upload File (FIRST TIME SETUP / ON DEMAND)
		File: routeUpload.txt
		Initial Header Sequence: 0052 
		
		Format:
		HD SEQ#      YYYY-MM-DD 
		|action code||Route Number||-----city label-----|*10
		T #ROWS
		
		Example:
		HD 0053      2016-03-18
		A0001Dearborn 1          Dearborn 2          Dearborn 3
		C0003Royal Oak
		D0005
		T 0003
	
	Truck Upload File (FIRST TIME SETUP / ON DEMAND)
		File: truckUpload.txt
		Initial Header Sequence: 0001
		
		Format: 
		HD SEQ#      YYYY-MM-DD 
		|Truck Number|
		T #ROWS
		
		Example:
		HD 0001      2016-03-24
		0001
		0010
		0110
		T 0003
		
	Driver Upload File (FIRST TIME SETUP / ON DEMAND)
		File: driverUpload.txt
		Initial Header Sequence: 0001
		
		Format: 
		HD SEQ#      YYYY-MM-DD 
		|Driver Number|
		T #ROWS
		
		Example:
		HD 0001      2016-03-24 
		0001 
		0002 
		0003
		T 0003
		
	Daily Inventory File (DAILY)
		File: dailyInventory.txt
		Initial Header Sequence: 9997
		
		Format: 
		HD SEQ#      YYYY-MM-DD 
		|Item Number||Warehouse Quantity||Initial Price||Sale Price||Description|
		T #ROWS IN FILE
		
		Example:
		HD 0025      2016-03-24 
		000300005005500650Chocolate Ice Cream
		000400010006500750Strawberry Ice Cream
		000500005207500850Mint Ice Cream
		000600005508500950Lemon Ice Cream
		000700006009501067Vanilla Ice Cream
		T 0005
		
	Load Truck Route Driver File (DAILY)
		File: truckRouteDriver.txt
		Initial Header Sequence: 9999
	
		Format:
		HD SEQ#      YYYY-MM-DD 
		|Truck Number||Route Number||Driver Number|
		T #ROWS
		
		Example:
		HD 0001      2016-03-24
		000100020003
		000200030005
		000300040001
		000400010002
		T 0004
		
	Load Ice Cream Truck Inventory File (ON DEMAND)
		File: loadTruck.txt
		Initial Header Sequence: 9999
		
		Format: 
		HD SEQ#      YYYY-MM-DD 
		TR |Truck Number|
		|Item Number||Adjustment Quantity|
		IR #ROWS FOR TRUCK
		T #ROWS IN FILE
		
		Example: 
		HD 0001      2016-03-24
		TR 0001
		00030500
		IR 0003
		TR 0002
		IR 0001
		T 0004
	
	Customer Request File (ON DEMAND)
		File: customerRequest.txt
		Initial Header Sequence: 0001
		
		Format:
		HD SEQ#      YYYY-MM-DD
		|Item Number||Description|
		T #ROWS IN FILE
		
		Example:
		HD 0001      2016-03-24
		0023Superman Ice Cream
		T 0001
		
	Sales File (DAILY)
		File: dailySales.txt
		Initial Header Sequence: 9998
		
		Format: 
		HD SEQ#      YYYY-MM-DD 
		TR |Truck Number|
		|Item Number||Final Quantity|
		SR #ROWS FOR TRUCK
		T #ROWS IN FILE
		
		Example:
		HD 0009      2016-03-12
		TR 0001
		00010001  
		00170002
		01180003
		SR 0003
		TR 0002
		01180003
		SR 0001
		T 0004

Program State
	Two Additional Functionalities Require Additional Files. The Header Sequence For driverUpload.txt and customerRequest.txt Should Be Set To 0001.
	
	The Sequence Numbers Are Set As Requested.
	
	The Current Date In The System Is 2016-03-24. To Continue, Dates In Files Must Be Greater Than This Date.
