CREATE TABLE IF NOT EXISTS tbl_accounts (
id INTEGER PRIMARY KEY ASC AUTOINCREMENT,
email VARCHAR(30) NOT NULL,
salt VARCHAR(256) NOT NULL,
salthash VARCHAR(256) NOT NULL
)
