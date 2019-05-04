CREATE FUNCTION [dbo].[GetAgents]
(
	@queues AS dbo.RecordIdList READONLY
)
RETURNS TABLE AS 
RETURN (
SELECT r.csqName, r.loggedinagents, r.availableagents
	FROM [DW_test].[enumeration].RtCSQsSummary as r
	left join [DW_test].[Enumeration].ContactServiceQueue csq on csq.csqName = r.csqname
	WHERE csq.recordID in (select * from @queues)
);