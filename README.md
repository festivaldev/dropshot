# Project Dropshot
An incomplete UberStrike server emulator developed by @SniperGER and @vainamov

## Features
- **Authentication**  
The UberStrike account you create will be linked to your Steam ID and saved in a database on the server, so every time you launch the game you will be automatically logged into your own account.
- **Inventory and Loadout**  
The server also saves your inventory and loadout, so you don't have to buy all your items again and again.
- **The biggest sale in the history of sales**  
The shop included in Project Dropshot contains most of the items ever introduced to UberStrike, including non-existent items such as handguns or other removed weapons. Every item is free and not locked to a level. Fair game for everyone.

## Setting up the client
### Requirements
- UberStrike installed from Steam (**steam://install/291210**)
- [dnSpy](https://github.com/0xd4d/dnSpy) - tool to modify C# Assemblies

---

- Open `steamInstallDir/common/UberStrike/UberStrike_Data` in File Explorer (where `steamInstallDir` is your Steam install directory).
- Create a new text file called `HostConfiguration.cfg`. This is the file that UberStrike will use to determine the host. You can enter `localhost` for now, but if the server is running on a different PC **in your network**, that PC's IP should go in there.
- Open `Managed/Assembly-CSharp.dll` in dnSpy
- Navigate to a class called `ApplicationDataManager` and locate the string variables `WebServiceBaseUrl` and `ImagePath` near the bottom.
- Right click on one of them, click "Edit Method (C#)" and replace `ApplicationDataManager.WebServiceBaseUrl` and `ApplicationDataManager.ImagePath` with the following code:
```csharp
ApplicationDataManager.WebServiceBaseUrl = "https://" + File.ReadAllText(Path.Combine(Application.dataPath, "HostConfiguration.cfg")) + "/2.0/";
ApplicationDataManager.ImagePath = "https://" + File.ReadAllText(Path.Combine(Application.dataPath, "HostConfiguration.cfg")) + "/images/";
```
Make sure the following `using` statements are included in the top section of that method:
```csharp
using System.IO;
using UnityEngine;
```
- Click "Compile" and the popup should disappear. Now click "File -> Save all" to save the changes.
- Open `Managed/Assembly-CSharp-firstpass.dll` in dnSpy
- Navigate to `UberStrike.WebService.Unity` and locate the following classes:
	- ApplicationWebServiceClient
	- AuthenticationWebServiceClient
	- ClanWebServiceClient
	- PrivateMessageWebServiceClient
	- RelationshipWebServiceClient
	- ShopWebServiceClient
	- UserWebServiceClient
- In every class, right click and select "Edit class (C#)".
- Replace every occurence of `UberStrike.DataCenter.WebService.CWS.[ServiceName]Contract.svc` with `[ServiceName]`
	- `[ServiceName]` is the name of the class you're editing without "Client" at the end
	- Tip: Ctrl+F is your friend
- Click "Compile" and the popup should disappear. Now click "File -> Save all" to save the changes.

You should now be able to connect to the server if you have one running.  
We hope we can simplify this process in the near future, but modifying an assembly automatically is hard.  
Also, we can't just redistribute the modified DLLs as Cmune is still the copyright holder and we want to respect that.

## Setting up the server
### Requirements
- UberStrike installed from Steam (**steam://install/291210**)
- Internet Information Services installed from Windows Features (Win+R -> `optionalfeatures.exe`)

---

- Download the latest release of Project Dropshot
- Copy the contents of the ZIP file into `steamInstallDir/common/UberStrike/UberStrike_Data/Managed` (where `steamInstallDir` is your Steam install directory)
	- Alternatively, you can copy `Assembly-CSharp-firstpass.dll`, `Photon3Unity3D.dll` and `UnityEngine.dll` to whereever you want your server to be installed
- Install the included certificate (`localhost.pfx`) before even thinking about launching the server right now.
- Open `inetmgr` and navigate to "Default Web Site" on the left.
- On the right, click on Bindings
- Click "Add", select "https" as the type (port should be 443), and select the "localhost" certificate you just installed.
- Click "Ok", select the "http" binding and click "Remove" (or leave it if you want to show Map icons)
- Close the window and click "Restart Server". Just in case.
- Now launch DropshotServer.exe and it should say "All Services running".

Now that the server is running, you can launch the modified UberStrike and explore weapons, items and maps.

To show map icons, put the image files inside the `Images` folder inside `C:\inetpub\wwwroot\images\maps`.

## Fix for localhost not showing up in inetmgr under Windows 7
- Run mmc.exe (windows icon button + r) 
- go to file, click on add/remove snap-ins
- choose certificates, click on add, in next window select computer account, then click next and then finish, and on previous window press ok
- double click on "certificates(local computer)", then double click on personal, then right click navigate to all tasks and click import
- in next window press next, then browse for localhost.pfx (in window where you browse for it, in drop list in right bottom edge select "Personal Information Exchange (*pfx,*p12)" and then it should show up" select it and press open
- press next, and then again next, in next window select "Place all certificates in the following store", and under certificate store browse for Personal, click next and then finish, and save everything.

## Known issues
- You cannot play with others (don't blame us for this, this takes a lot of time)
- Chat and messages don't work
- You can only explore maps and items
- Your player name is locked to "Player Name"
- Map icons are incomplete
- Shop data has not been updated yet (new version keeps selecting various unwanted items automatically)
- Other things

## Frequently Asked Questions
#### "FAKE NEWS!"
Nope, not at all. This project is actually working (even though you can't play with other people at this point, we consider it working). If you don't believe us, you know where the door is, right?
#### How does this work?
Simple: By redirecting the requests UberStrike sends to the "official" servers that have been shut down to a local server. The local server answers these requests by returning valid data.
#### Can we have our old accounts back?
No, unfortunately you can't. We dont't have access to Cmune's user database, so you'll have to start from the beginning. But fear not! All items are unlocked and free!
#### What about special items like Rank Shirts?
You can't have them unless you're that particular rank. Want to have a Moderator T-Shirt? Apply as a moderator and if you're picked, you will receive one.
#### Will you implement [insert feature here]?
This project is open source. You're welcome to implement it yourself. If you're not able to do this, we will have a look at it and decide if we're going to implement it or not.
#### Can you add [insert feature here] to the game?
No, we can't. We aren't game developers, we don't have the capabilities to do that. We only provide the solution to make the game playable again.
#### What about Quick Switching?
Quick Switching was a bug that has been fixed. But I've been told we're looking into that.
