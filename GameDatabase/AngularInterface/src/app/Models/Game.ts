
export class Game {
  name: string;
  description: string;
  coverArtUrl: string;
  developerId: number;
  developerName: string;
  publisherId: number;
  publisherName: string;
  genreId: number;
  genre: string;
  platform: string;
  reviews: Review;
  releaseDate: Date;
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
