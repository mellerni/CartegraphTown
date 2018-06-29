export class Point {

  public id: number = 0;
  public latitude: number | undefined;
  public longitude: number | undefined;
  public isCitizenLocation: boolean = true;
  public issueCount: number = 0;

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}