package sweep.it.up;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class DBConnectionManager
{
    private Connection connection;
     
    public DBConnectionManager(String dbURL, String user, String pwd) throws ClassNotFoundException, SQLException
    {
        Class.forName("com.mysql.jdbc.Driver");
        this.connection = DriverManager.getConnection(dbURL, user, pwd);
    }
     
    public Connection getConnection()
    {
        return this.connection;
    }
    
    public void SaveRecord(RawRecord record)
    {
		try
		{
			PreparedStatement ps = this.connection.prepareStatement("	insert into garbage(glass,plastmass,paper,metall,stones,sorted,longitude,latitude) values(?,?,?,?,?,?,?,?)");
	        
	        ps.setString(1, record.glass);
	        ps.setString(2, record.plastmass);
	        ps.setString(3, record.paper);
	        ps.setString(4, record.metall);
	        ps.setString(5, record.stones);
	        ps.setString(6, record.sorted);
	        ps.setString(7, record.longitude);
	        ps.setString(8, record.latitude);
	         
	        ps.execute();
		}
		catch (SQLException e)
		{
			e.printStackTrace();
		}
    }
    public String getMapData()
    {
    	try
    	{    		
			Statement st = this.connection.createStatement();
			String sql = ("SELECT if(TIMESTAMPDIFF(HOUR,date, curtime()) < 2, 'aabbcc', if(TIMESTAMPDIFF(HOUR,date,curtime())>12, 'ccbbaa', 'bbccaa')) as d,glass,plastmass,paper,metall,stones,longitude,latitude from garbage");
			ResultSet rs = st.executeQuery(sql);
			
			JSONArray points = new JSONArray();
			while(rs.next())
			{
				JSONObject point  = new JSONObject();
				
				point.put("bottle",   rs.getString("glass"));
				point.put("plastic",  rs.getString("plastmass"));
				point.put("paper",    rs.getString("paper"));
				
				point.append("coord", rs.getString("longitude"));
				point.append("coord", rs.getString("latitude"));
				
				points.put(point);
			}
	    	return points.toString();
		}
    	catch (JSONException | SQLException e)
    	{
			e.printStackTrace();
		}
    	return "";
    }
}
