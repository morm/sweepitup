package sweep.it.up.servlets;

import java.io.IOException;
import java.sql.SQLException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import sweep.it.up.DBConnectionManager;
import sweep.it.up.RawRecord;
/**
 * Servlet implementation class LocalsHandler
 */
@WebServlet("/sweepitupServlet")
public class LocalsHandler extends HttpServlet
{
	private static final long serialVersionUID = 1L;
	
    private static final String dbURL 	 = "jdbc:mysql://localhost/sweepitup";
    private static final String user 	 = "mor";
    private static final String password = "supervis";
	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
		//switch if request goes for html file or for ajax request
		switch(request.getParameter("req"))
		{
			case "get_index":
			{
				request.getRequestDispatcher("index.jsp").forward(request, response);
			}
			case "get_points":
			{
				try
				{
					DBConnectionManager dbman = new DBConnectionManager(dbURL, user, password);
					
					response.setContentType("application/json");
					response.getWriter().write(dbman.getMapData());
				}
				catch(ClassNotFoundException | SQLException e)
				{
					e.printStackTrace();
				}
			}
			default:
			{
				response.getWriter().write("Unknown content needed");
			}
		}
	}
		
	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
		try
		{
			DBConnectionManager dbman = new DBConnectionManager(dbURL, user, password);

			RawRecord record = new RawRecord(
										 request.getParameter("nick"),
										 request.getParameter("glass"),
										 request.getParameter("plastmass"),
										 request.getParameter("paper"),
										 request.getParameter("metall"),
										 request.getParameter("stones"),
										 request.getParameter("sorted"),
										 request.getParameter("longitude"),
										 request.getParameter("latitude"),
										 request.getParameter("email")
										);
			dbman.SaveRecord(record);
		}
		catch (ClassNotFoundException | SQLException e)
		{
			e.printStackTrace();
			response.getWriter().write(e.getMessage());
		}
	}
}