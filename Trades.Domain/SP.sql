CREATE PROCEDURE CategorizeTrades
AS
BEGIN
    -- Declare variables
    DECLARE @ID INT;
    DECLARE @Value DECIMAL(18,2);
    DECLARE @ClientSector VARCHAR(10);
    DECLARE @TradeCategory VARCHAR(20);

    -- Create temporary table for input trades
    CREATE TABLE #InputTrades (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Value DECIMAL(18,2) NOT NULL,
        ClientSector VARCHAR(10) NOT NULL
    );

    -- Insert input trades into temporary table
    INSERT INTO #InputTrades (Value, ClientSector)
    SELECT Value, ClientSector
    FROM Trades;

    -- Create table for output categories
    CREATE TABLE #OutputCategories (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        TradeCategory VARCHAR(20) NOT NULL
    );

    -- Loop through input trades and categorize them
    WHILE EXISTS(SELECT * FROM #InputTrades)
    BEGIN
        -- Get next trade from input table
        SELECT TOP 1 @ID = ID, @Value = Value, @ClientSector = ClientSector
        FROM #InputTrades
        ORDER BY ID;

        -- Categorize the trade based on its value and client sector
        IF @Value < 1000000 AND @ClientSector = 'Public'
            SET @TradeCategory = 'LOWRISK';
        ELSE IF @Value >= 1000000 AND @ClientSector = 'Public'
            SET @TradeCategory = 'MEDIUMRISK';
        ELSE IF @Value >= 1000000 AND @ClientSector = 'Private'
            SET @TradeCategory = 'HIGHRISK';
        ELSE
            SET @TradeCategory = 'UNKNOWN';

        -- Insert trade category into output table
        INSERT INTO #OutputCategories (TradeCategory)
        VALUES (@TradeCategory);

        -- Delete trade from input table
        DELETE FROM #InputTrades
        WHERE ID = @ID;
    END

    -- Select output categories
    SELECT TradeCategory
    FROM #OutputCategories;

    -- Clean up temporary tables
    DROP TABLE #InputTrades;
    DROP TABLE #OutputCategories;
END