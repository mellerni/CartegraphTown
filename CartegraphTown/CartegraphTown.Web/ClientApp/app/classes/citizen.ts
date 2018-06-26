export class Citizen {

  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  createdDate: Date;

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}