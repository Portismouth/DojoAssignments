export class Note {
    constructor(
      public id: number = null,
      public text: string = "",
      public created_at: Date = new Date(),
      public updated_at: Date = new Date()
    ){}
  }