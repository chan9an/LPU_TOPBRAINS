SELECT AlteringTables.sql
Asses1.sql
    blocking_session_id AS BlockingSessionId,
    r.session_id AS BlockedSessionId,
    r.status AS BlockedSessionStatus,
    r.wait_type AS WaitType,
    r.wait_time AS WaitTime,
    r.wait_resource AS WaitResource,
    r.cpu_time AS CpuTime,
    r.total_elapsed_time AS TotalElapsedTime,
    s.login_name AS BlockedSessionLoginName,
    s.host_name AS BlockedSessionHostName,
    s.program_name AS BlockedSessionProgramName,
    t.text AS BlockedSQLText,
    bs.login_name AS BlockingSessionLoginName,
    bs.host_name AS BlockingSessionHostName,
    bs.program_name AS BlockingSessionProgramName,
    bt.text AS BlockingSQLText
FROM 
    sys.dm_exec_requests r
    INNER JOIN sys.dm_exec_sessions s ON r.session_id = s.session_id
    LEFT JOIN sys.dm_exec_sessions bs ON r.blocking_session_id = bs.session_id
    CROSS APPLY sys.dm_exec_sql_text(r.sql_handle) AS t
    LEFT JOIN sys.dm_exec_sql_text(r.blocking_sql_handle) AS bt
WHERE 
    r.blocking_session_id <> 0 -- Only sessions that are being blocked
ORDER BY 
    r.wait_time DESC; -- You can change the ordering if you want to prioritize certain blocked sessions
