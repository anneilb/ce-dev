import java.io.Serializable;


public class ConferenceInfo implements Serializable {

	private String date = "";
	private int nrOfParticipants = 0; 
	private String sponsor = "";
	private String city = "";
	
	public String getDate() {
		return date;
	}

	public void setDate(String date) {
		this.date = date;
	}

	public int getNrOfParticipants() {
		return nrOfParticipants;
	}

	public void setNrOfParticipants(int nrOfParticipants) {
		this.nrOfParticipants = nrOfParticipants;	
	}

	public String getSponsor() {
		return sponsor;
	}

	public void setSponsor(String sponsor) {
		this.sponsor = sponsor;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public ConferenceInfo() {
		//Default constructor
	}

	public ConferenceInfo(String date, int nrOfParticipants, String sponsor, String city) {
		
		this.date = date;
		this.nrOfParticipants = nrOfParticipants;
		this.sponsor = sponsor;
		this.city = city;		
	}
}
