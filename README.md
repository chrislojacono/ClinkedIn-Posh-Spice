# ClinkedIn-Posh-Spice
# Description

You are an intrepid entrepreneur in the niche social network space.  Your latest trillion dollar idea is ClinkedIn, a social network for prisons.  This social network will allow inmates to create inmate accounts with their personal details, including why they're in prison, as well as to socialize and find friends with similar criminal interests.  You'll also be wanting a way to monetize this app, so having a section that allows for the listing of services is your entryway to the real money.  

You'll be building this in teams, and we're only concerned with building the API right now. 

## Example Repository Class

```csharp
class ClinkedInRepository
{
    static List<Clinker> _clinkers = new List<Clinker>();

    public List<Clinker> GetClinkers()
    {
        throw new NotImplementedException();
    }

    public void SaveNewClinker(Clinker newClinker)
    {
        throw new NotImplementedException();
    }
}
```

Your first task as a team will be to break down the following requirements into smaller chunks.  You are welcome to work on some tasks together, but everyone will need to have commits with substance.

# Requirements

As an incarcerated person

I want to join a social network

So that I'm not so lonely
#
As ClinkedIn member

I want to find other Clinkers by interest

So that I can make friends

Route: /api/interests/{type}
#
As a ClinkedIn member

I want to list my services

So that other inmates can ask me for help

Route: api/services/{inmateId}
#
As a ClinkedIn member

I want to keep track of my friends

So that I can know who has my back

Route: api/members/{inmateId}/friends
#
As a ClinkedIn member

I want to keep track of my enemies

So that I know who to watch out for

Route: api/members/{inmateId}/enemies

# Stretch Goals

As a ClinkedIn member

I want to know who my friends' friends are

So that I can build up my crew

Route: api/members/getAllFriends/{inmateId}
#
As a Clinker

I want to update and remove pieces of information, like interests and services

So that as I evolve as a person I can let everyone know

#
As a Warden

I want to get all inmates information

So that I can peruse the population

Route: api/warden
#
As a Clinker 

I want to know how many days remain in my sentence

So that I can keep track

Route: api/members/{inmateId}/sentence
