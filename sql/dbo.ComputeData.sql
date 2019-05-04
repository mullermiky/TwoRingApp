CREATE PROCEDURE [dbo].[ComputeData]
	@from DateTime,
	@to DateTime,
	@queues AS varchar(max)
AS
	declare @table as dbo.RecordIdList
	select * into #t from string_split(@queues, ',')

	IF(@queues != '')
		insert into @table(ID) select csq.recordID from #t 
		join enumeration.ContactServiceQueue csq on csq.csqName = #t.value
	ELSE
		insert into @table(ID) select recordID from enumeration.ContactServiceQueue; 


	SELECT * into #tbl1 from dbo.GetNumberOfCalls(@from, @to, @table);
	SELECT * into #tbl2 from dbo.GetNumberOfAbandonedCalls(@from, @to, @table);
	SELECT * into #tbl3 from dbo.GetNumberOfHandledCalls(@from, @to, @table);

	SELECT * into #tbl4 from dbo.GetAgents(@table);

	select 
	t4.*,
	t1.numberOfCalls,
	t2.numberOfAbandonedCalls, 
	t3.numberOfhandledCalls
	into #tbl5
	from #tbl4 t4
	left join #tbl1 t1 on t4.csqName = t1.csqName
	left join #tbl2 t2 on t2.targetID = t1.targetID
	left join #tbl3 t3 on t3.targetID = t1.targetID

	update #tbl5 set numberOfCalls = 0 where numberOfCalls is null
	update #tbl5 set numberOfAbandonedCalls = 0 where numberOfAbandonedCalls is null
	update #tbl5 set numberOfhandledCalls = 0 where numberOfhandledCalls is null

	select * from #tbl5

	drop table #tbl1
	drop table #tbl2
	drop table #tbl3
	drop table #tbl4
	drop table #tbl5
RETURN 0