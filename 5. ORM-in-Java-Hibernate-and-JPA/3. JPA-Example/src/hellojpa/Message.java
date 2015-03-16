package hellojpa;
import java.util.Date;

import javax.persistence.*;

/**
 * A very simple persistent entity that holds a "message", has a
 * "created" field that is initialized to the time at which the
 * object was created, and an id field that is initialized to the
 * current time.
 */
@Entity
@Table(name="MESSAGES")
public class Message {
    @Id
    private long id = System.currentTimeMillis();

    //@Basic
    @Column(name="MSG")
    private String message;

    //@Basic
    @Column(name = "CRTDWHATEVER")
    private Date created = new Date();

    public Message() {
    }

    public Message(String msg) {
        message = msg;
    }

    public void setId(long val) {
        id = val;
    }

    public long getId() {
        return id;
    }

    public void setMessage(String msg) {
        message = msg;
    }

    public String getMessage() {
        return message;
    }

    public void setCreated(Date date) {
        created = date;
    }

    public Date getCreated() {
        return created;
    }
}
