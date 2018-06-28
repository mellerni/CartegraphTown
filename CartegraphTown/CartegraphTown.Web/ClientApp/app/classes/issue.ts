export class Issue {

  public id: number = 0;
  public issueTypeDescription: string = "";
  public issueTypeId: number = 0;
  public citizen: string = "";
  public citizenId: number = 0;
  public location: string = "";
  public details: string = "";
  public correctiveAction: string = "";
  public correctionDate: Date | undefined;
  public createdDate: Date = new Date();

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}