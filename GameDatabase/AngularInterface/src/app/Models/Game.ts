export class Game {
  name: string;
  description: string;
  CoverArtUrl: string;
  developerId: number;
  publisherId: number;
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
