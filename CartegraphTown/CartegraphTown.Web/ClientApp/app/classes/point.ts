export class Point {

  public id: number = 0;
  public latitude: string | undefined;
  public longitude: string | undefined;
  public isCitizenLocation: boolean = true;
  public issueCount: number = 0;

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}