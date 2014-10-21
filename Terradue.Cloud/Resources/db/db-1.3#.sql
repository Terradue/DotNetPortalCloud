USE $MAIN$;

/*****************************************************************************/

-- Changing structure of table "cloudprov" (add new type reference) ... \
ALTER TABLE cloud
    ADD COLUMN id_usr int unsigned COMMENT 'FK: Owning user (optional)' AFTER id_type,
    ADD CONSTRAINT fk_cloud_usr FOREIGN KEY (id_usr) REFERENCES usr(id) ON DELETE SET NULL
;
-- RESULT


/*****************************************************************************/
