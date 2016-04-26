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

By Winter Water Interactive

MANUAL

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

Warnings:
* Do Not Delete Database Files. This Will Delete All Data In The Software.
* Do Not Delete .exe or DLL Files. This Will Remove The Software From System.
* File Processing Is Character Sensitive. Data Must Fit All Spaces Exactly.
* Files must be submitted in the correct order.
* Route, Truck, Driver, and Item Numbers MUST NOT BE ZERO. This May Cause Errors in the Software.

Assumptions:
* Must have internet connection for Text Message Notification system.

How To Use The Software
	1. Place files in a safe directory that you will access within the program. 
	2. Make sure file names and the data in them are correct. Example files and names shown below. 
	3. Click the browse button that corresponds to the file you'd like to upload. 
	4. Once data is processed, you may access tables with the sorted data.

Files
	The Program Accepts Several Different Files. They All Vary By Name And Data.
	
	City Upload File
		File: cityUpload.txt
		
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
	
	Daily Inventory File
		File: dailyInventory.txt
		
		Format: 
		HD SEQ#      YYYY-MM-DD 
		|Item Number||Warehouse Quantity||Price||Description|
		T #ROWS IN FILE
		
		Example:
		HD 0025      2016-03-24 
		000300005005500650Chocolate Ice Cream
		000400010006500750Strawberry Ice Cream
		000500005207500850Mint Ice Cream
		000600005508500950Lemon Ice Cream
		000700006009501067Vanilla Ice Cream
		T 0005
		
	Route Upload File
		File: routeUpload.txt
		
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
	
	Truck Upload File
		File: truckUpload.txt
		
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
		
	Driver Upload File
		File: driverUpload.txt
		
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
		
	Load Truck Route Driver File
		File: truckRouteDriverUpload.txt
	
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
		
	Load Ice Cream Truck Inventory File
		File: loadTruck.txt
		
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

	Sales File
		File: dailySales.txt
		
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
