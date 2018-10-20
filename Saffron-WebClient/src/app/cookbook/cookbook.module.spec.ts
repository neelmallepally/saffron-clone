import { CookbookModule } from './cookbook.module';

describe('CookbookModule', () => {
  let cookbookModule: CookbookModule;

  beforeEach(() => {
    cookbookModule = new CookbookModule();
  });

  it('should create an instance', () => {
    expect(cookbookModule).toBeTruthy();
  });
});
