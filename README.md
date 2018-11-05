# Azure Bootcamp Hands-On Session 3

Data Ingestion in Azure (Storage Account & Serverless /API) - Skript
## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

* [Power BI Desktop engl.](https://powerbi.microsoft.com/en-us/downloads/)
* [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)

## 1.) Am Azure Portal anmelden

https://portal.azure.com

## 2.) Azure Resource Group (RG) erstellen

a. In Navigationsleiste auf „Create a resource“ klicken

b. Nach “Resoure Group” suchen

c. Auf “Create” klicken

d. Resource group name: rg-azbootcamp-[RACF]

e. Subscription:

f. Resource Group Location: West Europe

g. “Create” klicken und unter “Resource groups” oder “all resources” nach erstellter RG suchen

## 3.) Azure Function App erstellen

a. In Navigationsleiste auf „Create a resource“ klicken und nach „Function App“ suchen

b. Auf „Create“ klicken

c. App name: stellenmarktNRW[RACF]

d. Subscription:

e. Resource Group (Use existing: unter 2. Erstellte RG auswählen)

f. OS: Windows

g. Hosting Plan: Consumption Plan

h. Location: West Europe

i. Runtime Stack: .NET

j. Storage (Create new):

k. Application Insights: On

l. Application Insights Location: West Europe

m. “Create” klicken und nach erstellter Function in RG suchen

## 4.) Function erstellen

a. Zur Function App navigieren

b. „+ New function“ oder unter „Functions“ auf „+“ klicken

c. Als „Deployment Environment“ „In-portal“ auswählen und auf „Continue“

d. Als Function „Timer“ auswählen und auf „Create“ klicken

e. Auf Function klicken und erst einmal disablen

## 5.) Github: Dateien herunterladen

a. https://github.com/ArvatoSystems/Serverless-HandsOn3 > Clone or Download > Download ZIP

b. entpacken

## 6.) C#-Klassen implementieren/einbinden

a. Im Portal zur Function navigieren und unter „Functions“ den erstellten „TimerTrigger“ aufrufen (es sollte der Quellcode der run.csx zu sehen sein)

b. Rechts auf „View Files“ klicken und die Dateien json.csx, jobItem.csx und mapper.csx in das Verzeichnis hochladen

## 7.) TimerTrigger-Function implementieren

a. Den Code der run.csx gegen den Code in der mitgelieferten run.csx austauschen und „save and run“

## 8.) Power BI

a. Power BI Desktop starten und auf „Get data“ klicken

b. Unter „Azure“ „Azure Table Storage“ auswählen und „Connect“ drücken

c. URL eingeben (im Storage Account unter „Properties“ und „Primary Table Service End-point“ oder unter “Tables”)

d. Access Key eingeben (im Sorage Account unter “Access Keys”)

e. Table auswählen und Daten importieren (eventuell ist Transformation nötig)

f. Daten einmal visualisieren (lasst eurer Phantasie freien Lauf!)

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
