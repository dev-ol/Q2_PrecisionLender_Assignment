SELECT t.Id, t.Summary, n.NewStatus
FROM
    (SELECT l.TicketId, l.LatestTime, s.NewStatus, s.[Timestamp]
    FROM
        (
    SELECT TicketId, MAX(Timestamp) as LatestTime
        FROM StatusChange
        GROUP BY TicketId
) as l
        JOIN StatusChange as s ON  s.[Timestamp] =  l.LatestTime
        AND s.TicketId = l.TicketId
    WHERE s.NewStatus IN ('In Progress', 'Reopened')) as n
    JOIN TicketTable as t
    ON n.TicketId = t.Id