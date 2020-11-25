import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  user: any = new User();
  premiumAmount: any = 0;
  isShowMsg: boolean = false;
  occupationList: any[] = [
    {
      "id": 1,
      "occupation": "Cleaner",
    },
    {
      "id": 2,
      "occupation": "Doctor",
    },
    {
      "id": 3,
      "occupation": "Author",
    },
    {
      "id": 4,
      "occupation": "Farmer",
    },
    {
      "id": 5,
      "occupation": "Mechanic",
    },
    {
      "id": 6,
      "occupation": "Florist",
    }
  ];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    this.user.occupation = "";
  }

  onSubmit() {
    let deathPremium = new DeathPremium();
    deathPremium.dob = this.user.dateOfBirth;
    deathPremium.deathCoverAmount = parseFloat(this.user.deathAmount.toString());
    deathPremium.occupationId = parseInt(this.user.occupation.toString());

    this.http.post<string>(this.baseUrl + 'home', deathPremium).subscribe(result => {
      if (result == "-1") {
        this.premiumAmount = "age is invalid";
        this.isShowMsg = false;
      } else {
        this.premiumAmount = parseFloat(result.toString());
        this.isShowMsg = true;
      }
    }, error => console.error(error));
  }


}


export class User {
  public name: string;
  public age: number;
  public dateOfBirth: Date;
  public occupation: number;
  public deathAmount: number;
}

export class DeathPremium {
  public dob: Date;
  public deathCoverAmount: number;
  public occupationId: number;
}
