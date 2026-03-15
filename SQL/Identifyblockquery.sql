SELECT
    blocking_session.session_id AS BlockingSessionId,
    blocking_session.login_name AS BlockingLogin,
    blocked_session.session_id AS BlockedSessionId,
    blocked_session.login_name AS BlockedLogin,
    req.wait_type,
    req.wait_time,
    req.blocking_session AS BlockingSessionInReq,
    txt.text AS SqlText
FROM sys.dm_exec_requests req
INNER JOIN sys.dm_exec_sessions blocked_session
    ON req.session_id = blocked_session.session_id
LEFT JOIN sys.dm_exec_sessions blocking_session
    ON req.blocking_session = blocking_session.session_id
CROSS APPLY sys.dm_exec_sql_text(req.sql_handle) AS txt
WHERE req.blocking_session <> 0
ORDER BY req.wait_time DESC;
