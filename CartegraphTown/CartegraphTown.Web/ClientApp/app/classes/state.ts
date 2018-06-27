export class State {

  public int: number = 0;
  public abbreviation: string = "";

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}