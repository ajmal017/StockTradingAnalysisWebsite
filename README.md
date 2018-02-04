Stock Trading Analysis
=====================================
This application can be used to manage stock transactions and maintaining a diary by adding stocks, transactions for these stocks, feedback and strategies. Based on all transactions key performance indicators etc. are calculated for different time periods. Also stock quotes can be downloaded automatically.


History
--------------
This application already exists in an old version which was developed by the motto "getting things done" by utilizing a relational database. I've decided to re-develop the whole application with techniques which are more sophisticated like [CQRS](https://martinfowler.com/bliki/CQRS.html) and [Eventsourcing](https://martinfowler.com/eaaDev/EventSourcing.html).

The projects `StockTradingAnalysis.Web.Migration` is used to load all data from the relational database to the object oriented database by firing commands and thus using the event sourcing system.

Setup project with MSSQL ([RavenDB](https://ravendb.net/) exists as well)
--------------
1. Create a new database
2. Execute the script `StockTradingAnalysis.Data.MSSQL.Scripts.Create_DataStore_Table.sql`
3. Run multiple projects (`StockTradingAnalysis.Web` and `StockTradingAnalysis.Services.StockQuoteService`). Can be done by right-click on the solution in Visual Studio and go to "Set Startup Projects".
4. (NOT FINISHED) Run test data creation

Technologies & Approaches
--------------
1. [CQRS](https://martinfowler.com/bliki/CQRS.html)
2. [Eventsourcing](https://martinfowler.com/eaaDev/EventSourcing.html)
3. [RavenDB](https://ravendb.net/)
4. [Bootstrap](https://getbootstrap.com/)
5. [SignalR](https://www.asp.net/signalr)
6. [ReactJs.NET](https://reactjs.net/])

Application infrastructure
--------------
Diagram coming soon

Features
--------------
* Dashboard
  * Savings plan based on assigned categories for transactions
* Transactions
  * Buy, Sell, Dividend, Split/Reverse split
* Stocks
* Feedback
* Strategies
* Calculation for buying decisions and open positions
  * Stop loss, take profit, price, amount etc. can be configured
  * Historical/daily basis quotes can be downloaded (if stock with WKN was configured)

Features (not yet migrated)
--------------
* Dashboard
  * KPI
    * Amount of trades
    * Amount of winning/losing trades
    * Amount of trades per year/month/week
    * System quality number (SQN)
    * Pay-Off-Ratio
    * CRV
    * Expected values
    * Average win/loss
    * Maximum win/loss
    * Average buying volume
    * Order costs/taxes
    * Average holding period intraday/long term positions
    * Best asset class
    * Best assert
    * Maximum drawdown
    * Maximum consecutive winners/losers
    * Exit/Entry efficiency
    * Open positions
  * Statistics: Last 10/25/50/75/100/150/All Trades (profit, loss, payoff-ratio, CRV,CQN etc.)
  * Performance: over asset class, long/short, strategy, monthly performance
  * Potential: MAE,MFE
  * G/V: Expected value, trade stability, G/V size distribution, depot P&L, hit rate
  * Risk: cluster analysis, monte carlo simulation
  * Savings plan: products, export
* Performance
  * All performance key indicators with filtering over time range & asset class
* Transactions  
  * Export

Images
--------------
![calculation](https://user-images.githubusercontent.com/29073072/35777955-055ff46a-09b7-11e8-9ec1-3704a4aca895.png)