export class Issue {

  public id: number = 0;
  public issueTypeDescription: string = "";
  public issueTypeId: number = 0;
  public citizen: string = "";
  public citizenId: number | undefined;
  public location: string = "";
  public locationId: number | undefined;
  public details: string = "";
  public correctiveAction: string = "";
  public correctionDate: Date | undefined;
  public createdDate: Date = new Date();

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}