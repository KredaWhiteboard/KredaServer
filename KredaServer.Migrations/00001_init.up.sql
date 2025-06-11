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

CREATE TABLE shapes (
    id UUID PRIMARY KEY, 
    whiteboard_id UUID NOT NULL, 
    brush_size SMALLINT NOT NULL,
    r SMALLINT NOT NULL,
    g SMALLINT NOT NULL,
    b SMALLINT NOT NULL,
    a SMALLINT NOT NULL,
    is_shape BOOLEAN NOT NULL;
    CONSTRAINT fk_whiteboard_id_id FOREIGN KEY(whiteboard_id) REFERENCES whiteboards(id) ON DELETE CASCADE
);

CREATE TABLE dots (
    shape_id UUID NOT NULL, 
    x INT NOT NULL,
    y INT NOT NULL,
    order INT NOT NULL,
    CONSTRAINT fk_shapes_id_id FOREIGN KEY(shape_id) REFERENCES shapes(id) ON DELETE CASCADE
);