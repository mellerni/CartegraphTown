export class Point {

  public id: number = 0;
  public latitude: string | undefined;
  public longitude: string | undefined;
  public createdDate: Date = new Date();

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}