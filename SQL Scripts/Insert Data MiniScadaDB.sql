-- Insert data into Rtus tables.
INSERT INTO DbRtus (rtu_id, rtu_name, ip_address, rtu_port) VALUES (1, 'RTU1', '127.0.0.1', 502)
INSERT INTO DbRtus (rtu_id, rtu_name, ip_address, rtu_port) VALUES (2, 'RTU2', '127.0.0.1', 503)

-- Insert data into Mappings.
-- Analog mappings
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(1, 'Mapping 1', 0.008, -40)
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(2, 'Mapping 2', 0.1, -300)
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(3, 'Mapping 3', 0.02, -100)
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(4, 'Mapping 4', 0.01, -100)
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(5, 'Mapping 5', 0.008, -40)

-- Discrete mappings
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(6, 'Mapping 6', NULL, NULL)
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(7, 'Mapping 7', NULL, NULL)
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(8, 'Mapping 8', NULL, NULL)
INSERT INTO DbMappings(mapping_id, mapping_name, K, N) 
	VALUES(9, 'Mapping 9', NULL, NULL)


-- Insert data into Signals tables (RTU 1).
-- Analog signals
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id, rtu_id)
	VALUES (1, 'Napon 1', 1, 0.1, '00:00:01', 1, NULL, 1, 1)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (2, 'Temperatura 1', 2, 0.1, '00:00:01', 1, NULL, 2, 1)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (3, 'Napon 2', 1, 0.1, '00:00:01', 0, NULL, 1, 1)
-- Discrete signals
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (4, 'Discrete signal 1', 1, 0.1, '00:00:01', 1, 1, 6, 1)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (5, 'Discrete signal 2', 3, 0.1, '00:00:01', 1, 0, 6, 1)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (10, 'Discrete signal 3', 1, 0.1, '00:00:01', 0, 1, 7, 1)

-- Insert data into Signals tables (RTU 2).
-- Analog signals
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (6, 'Napon 1', 1, 0.1, '00:00:01', 1, NULL, 3, 2)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (7, 'Temperatura 1', 4, 0.1, '00:00:01', 1, NULL, 4, 2)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (13, 'Napon 2', 1, 0.1, '00:00:01', 0, NULL, 5, 2)
-- Discrete signals
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (8, 'Prekidac 3', 1, 0.1, '00:00:01', 1, 0, 8, 2)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (9, 'Prekidac 4', 2, 0.1, '00:00:01', 1, 1, 9, 2)
INSERT INTO DbSignals (signal_id, signal_name, signal_address, deadband, stale_time, access_type, discrete_signal_type, mapping_id,  rtu_id)
	VALUES (12, 'Prekidac 5', 1, 0.1, '00:00:01', 0, 1, 8, 2)

-- Insert data into ScanPeriods table.
INSERT INTO DbScanPeriods (scan_id, scan_name, scan_period) VALUES (1, 'Period mapping 1', '00:00:02')
INSERT INTO DbScanPeriods (scan_id, scan_name, scan_period) VALUES (2, 'Period mapping 2', '00:00:05')
INSERT INTO DbScanPeriods (scan_id, scan_name, scan_period) VALUES (3, 'Period mapping 3', '00:00:10')

-- Insert data into CronExpressions table.
INSERT INTO DbCronExpressions (cron_id, cron_name, cron_start, cron_end, recurrence_period, recurrence_type) 
	VALUES(1, 'Cron expression 1', '2023-10-10 01:00:10', '2024-10-10 00:00:10', 5, 1);
INSERT INTO DbCronExpressions (cron_id, cron_name, cron_start, cron_end, recurrence_period, recurrence_type) 
	VALUES(2, 'Cron expression 2', '2023-10-10 01:00:10', '2024-10-10 00:00:10', 3, 0);
INSERT INTO DbCronExpressions (cron_id, cron_name, cron_start, cron_end, recurrence_period, recurrence_type) 
	VALUES(3, 'Cron expression 3', '2023-10-10 01:00:10', '2024-10-10 00:00:10', 10, 0);

-- Insert data into DiscreteValueToState
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (1, 0, 'Error', 6)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (1, 1, 'Open', 6)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (1, 2, 'Close', 6)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (1, 3, 'Transit', 6)

INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (2, 0, 'On', 7)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (2, 1, 'Off', 7)

INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (3, 0, 'Error', 8)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (3, 1, 'High', 8)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (3, 2, 'Low', 8)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (3, 3, 'Transit', 8)

INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (4, 0, 'Error', 9)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (4, 1, 'On', 9)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (4, 2, 'Off', 9)
INSERT INTO DbDiscreteValueToState(value_to_state_id, discrete_value, discrete_state, mapping_id) VALUES (4, 3, 'Transit', 9)

