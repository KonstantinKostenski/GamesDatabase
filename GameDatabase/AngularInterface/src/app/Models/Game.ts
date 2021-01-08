export class Game {
  name: string;
  description: string;
  CoverArtUrl: string;
  developerId: number;
  developer: string;
  publisherId: number;
  publisher: string;
  genreId: number;
  platform: string;
  reviews: Review;
}

export class Review {
  authorId: string;
  gameId: number;
  title: string;
  text: string;
}

export class Search {
  Name: string;
}
