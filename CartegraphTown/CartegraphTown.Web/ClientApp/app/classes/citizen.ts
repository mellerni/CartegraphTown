export class Citizen {

  public id: number = 0;
  public firstName: string = "";
  public lastName: string = "";
  public email: string = "";
  public phone: string = "";
  public createdDate: Date = new Date();

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}