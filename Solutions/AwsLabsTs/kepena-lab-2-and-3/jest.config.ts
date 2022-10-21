import { pathsToModuleNameMapper } from 'ts-jest/utils';
import { compilerOptions } from './tsconfig.paths.json';

const jestConfig = {
  collectCoverage: true,
  coverageReporters: [
    'cobertura',
    'html',
    'text-summary'
  ],
  moduleNameMapper: pathsToModuleNameMapper(compilerOptions.paths, { prefix: '<rootDir>/' }),
  testResultsProcessor: 'jest-junit',
  transform: {
    '^.+\\.ts?$': 'ts-jest'
  },
  verbose: true
}

export default jestConfig;