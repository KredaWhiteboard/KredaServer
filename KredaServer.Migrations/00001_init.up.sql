CREATE TABLE whiteboards (
    id UUID PRIMARY KEY,
    created_at TIMESTAMPTZ NOT NULL
);

CREATE TABLE users (
    id UUID PRIMARY KEY, 
    username VARCHAR(100) NOT NULL,
    whiteboard_id UUID NOT NULL, 
    created_at TIMESTAMPTZ NOT NULL,

    CONSTRAINT fk_whiteboard_id_id FOREIGN KEY(whiteboard_id) REFERENCES whiteboards(id) ON DELETE CASCADE
);