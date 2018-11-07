export class Cookbook {
    id: string;
    title: string;
    sections: Section[]
  }
  
  export interface Section {
    id: string;
    title: string;
    order: number;
  }