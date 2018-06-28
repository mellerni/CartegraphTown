export class TypeAhead {

  public int: number = 0;
  public description: string = "";

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}