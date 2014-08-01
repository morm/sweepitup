package sweep.it.up;

public class RawRecord
{
	public String user;
	public String glass;
	public String plastmass;
	public String paper;
	public String metall;
	public String stones;
	public String sorted;
	public String longitude;
	public String latitude;
	public String email;
	
	public RawRecord(String user_, 
					 String glass_,  	String plastmass_, 
					 String paper_,  	String metall_, 
					 String stones_, 	String sorted_,
					 String longitude_, String latitude_,
					 String email_)
	{
		 user 		= user_;
		 glass 		= glass_;
		 plastmass 	= plastmass_;
		 paper 		= paper_;
		 metall 	= metall_;
		 stones 	= stones_;
		 sorted 	= sorted_;
		 longitude 	= longitude_;
		 latitude 	= latitude_;
		 email 		= email_;
	}
}
