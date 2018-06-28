export class IssueType {

  public id: number = 0;
  public type: string = "";

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}