using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
public class LoginService : ILoginService
{

    BookReviewDbEntities db = new BookReviewDbEntities();
    public bool RegisterReviewer(Reviewer r)
    {
        //this registers a new reviewer using
        //the stored procedure usp_NewReviewer
        //the stored procedure takes the fields listed
        //as parameters. It returns 0 if good
        //and -1 if the registration fails
        //usernames and emails must be unique
        bool result = true;
        int pass = db.usp_NewReviewer
            (r.ReviewerUserName,
            r.ReviewerFirstName,
            r.ReviewerLastName,
            r.ReviewerEmail,
            r.ReviewPlainPassword);
        if (pass == -1)
        {
            result = false;
        }

        return result;
    }

    public int ReviewerLogin(string userName, string password)
    {
        //logs in a reviewer using the stored Procedure
        //usp_Reviewer Login
        // returns 0 if succeeds
        //-1 if it fails. (not the same as the reviewerKey
        //which is also set to 0)
        //when
        int reviewerKey = 0;
        int result = db.usp_ReviewerLogin(userName, password);
        if (result != -1)
        {
            var key = (from r in db.Reviewers
                      where r.ReviewerUserName.Equals(userName)
                      select new { r.ReviewerKey }).FirstOrDefault();

            reviewerKey = key.ReviewerKey;

          }
        return reviewerKey;

    }
}
