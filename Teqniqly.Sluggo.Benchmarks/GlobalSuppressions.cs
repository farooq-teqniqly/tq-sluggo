using System.Diagnostics.CodeAnalysis;

// Benchmark methods with underscores for readability are acceptable
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]

// Benchmark classes must be public for BenchmarkDotNet to discover them
[assembly: SuppressMessage("Design", "CA1515:Consider making public types internal")]

// Benchmark methods must be instance methods, not static
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static")]

// List<T> is appropriate for benchmark methods measuring collection performance
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists")]
