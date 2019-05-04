/****** Script for SelectTopNRows command from SSMS  ******/

declare @tmp as [RecordIdList]

	insert into @tmp 
	select 60


exec dbo.ComputeData @from = '2017-12-31', @to = '2019-05-02', @queues = @tmp
