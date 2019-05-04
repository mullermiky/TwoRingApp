CREATE FUNCTION [dbo].[GetNumberOfAbandonedCalls]
(
	@from DateTime,
	@to DateTime,
	@queues AS dbo.RecordIdList READONLY
)
RETURNS TABLE AS 
RETURN (
SELECT 
	cqd.targetID,
	COUNT(ccd.contactDisposition) as numberOfAbandonedCalls
	FROM [DW_test].[journal].[ContactQueueDetail] cqd
	left join [DW_test].[journal].[ContactCallDetail] ccd on ccd.sessionID = cqd.sessionID and ccd.sessionSeqNum = cqd.sessionSeqNum and ccd.nodeID = cqd.nodeID
	where cqd.targetType = 0 and ccd.contactDisposition = 1 and ccd.uccxLocalStartDateTime > @from and ccd.uccxLocalStartDateTime < @to and cqd.targetID in (select * from @queues)
	group by cqd.targetID
);