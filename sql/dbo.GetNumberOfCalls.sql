
CREATE FUNCTION [dbo].[GetNumberOfCalls]
(
	@from DateTime,
	@to DateTime,
	@queues AS dbo.RecordIdList READONLY
)
RETURNS TABLE AS 
RETURN (
SELECT
	csq.csqName,
	cqd.targetID,
	COUNT(cqd.sessionID) as numberOfCalls

	FROM [DW_test].[journal].[ContactQueueDetail] cqd
	left join [DW_test].[enumeration].[ContactServiceQueue] csq on csq.recordID = cqd.targetID 
	where cqd.targetType = 0 and cqd.uccxLocalStartDateTime > @from and cqd.uccxLocalStartDateTime <= @to and (csq.recordID IN (SELECT ID from @queues))
	group by csq.csqName, cqd.targetID
);