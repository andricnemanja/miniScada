CREATE TABLE DbRtus (
	rtu_id INT PRIMARY KEY,
	rtu_name VARCHAR(255) NOT NULL,
	ip_address VARCHAR(20) NOT NULL,
	rtu_port INT NOT NULL
);

CREATE TABLE DbMappings (
	mapping_id INT PRIMARY KEY,
	mapping_name VARCHAR(255) NOT NULL,
	K REAL,
	N REAL
);

CREATE TABLE DbSignals (
	signal_id INT PRIMARY KEY,
	signal_name VARCHAR(255) NOT NULL,
	signal_address INT NOT NULL,
	deadband REAL NOT NULL,
	stale_time TIME NOT NULL,
	access_type INT NOT NULL CHECK(access_type IN (0, 1)), -- 0 - Input, 1 - Output
	discrete_signal_type INT CHECK(discrete_signal_type IN (NULL, 0, 1)), -- NULL - Analog signal, 0 - OneBit, 1 - TwoBit
	mapping_id INT  NOT NULL,
	rtu_id INT NOT NULL,

	FOREIGN KEY (rtu_id) REFERENCES DbRtus (rtu_id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (mapping_id) REFERENCES DbMappings (mapping_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE DbScanPeriods (
	scan_id INT PRIMARY KEY,
	scan_name VARCHAR (255) NOT NULL,
	scan_period TIME NOT NULL
);

CREATE TABLE DbCronExpressions (
	cron_id INT PRIMARY KEY,
	cron_name VARCHAR(255) NOT NULL,
	cron_start DATETIME NOT NULL,
	cron_end DATETIME NOT NULL,
	recurrence_period INT NOT NULL,
	recurrence_type INT NOT NULL CHECK (recurrence_type IN (0, 1, 2, 3, 4, 5))
	-- 0 - seconds, 1 - minutes, 2 - hours, 3 - days, 4 - weeks, 5 - months
);

CREATE TABLE DbDiscreteValueToState (
	value_to_state_id INT NOT NULL,
	discrete_value TINYINT NOT NULL,
	discrete_state VARCHAR(255) NOT NULL,
	mapping_id INT NOT NULL,

	PRIMARY KEY (value_to_state_id, discrete_value),

	FOREIGN KEY (mapping_id) REFERENCES DbMappings (mapping_id) ON DELETE CASCADE ON UPDATE CASCADE
);	