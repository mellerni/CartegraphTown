import { Point } from './point';

export class Address {

  public id: number = 0;
  public address1: string = "";
  public address2: string = "";
  public city: string = "";
  public state: string = "";
  public stateId: number | undefined;
  public zipCode: string = "";
  public isCitizenLocation: boolean = true;
  public issueCount: number = 0;
  public createdDate: Date = new Date();

  point: Point = new Point();

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}