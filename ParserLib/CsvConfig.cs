using System;

namespace ParserLib
{
    [Flags]
    public enum TrimmingOptions
    {
        /// <summary>
        /// Return all text between the field delimiters/record delimiters.
        /// </summary>
        None = 0,
        /// <summary>
        /// Trim unquoted fields
        /// </summary>
        Unquoted = 1,
        /// <summary>
        /// Trim inside the quotes of a quoted field.
        /// </summary>
        QuotedInside = 2,
        /// <summary>
        /// Trim outside the quotes of a quoted field.
        /// </summary>
        QuotedOutside = 4,
        /// <summary>
        /// Trim inside and outside the quotes of a quoted field.
        /// </summary>
        Quoted = QuotedInside | QuotedOutside,
        /// <summary>
        /// Trim all fields.
        /// </summary>
        All = Unquoted | Quoted
    }

    public enum VaryingArityOptions
    {
        /// <summary>
        /// Call error action with appropriate error action
        /// </summary>
        Throw,
        /// <summary>
        /// Return the additional values regardless.
        /// </summary>
        Return,
        /// <summary>
        /// Proceed to the next record without returning
        /// </summary>
        DiscardRecord,
        // Not used as they can be done caller side
        ///// <summary>
        ///// Perform a custom action with the record and discard it
        ///// </summary>
        //CustomActionDiscard,
        ///// <summary>
        ///// Perform a custom action with the record and return it
        ///// </summary>
        //CustomActionReturn
    }

    public enum ExtraFieldOptions
    {
        /// <summary>
        /// Call error action with appropriate error action
        /// </summary>
        Throw,
        /// <summary>
        /// Return the additional values regardless.
        /// </summary>
        Return,
        /// <summary>
        /// Proceed to the next record without returning
        /// </summary>
        DiscardRecord,

        /// <summary>
        /// Discard extra values if there are more than the first record / number of headers (if present)
        /// </summary>
        DiscardValues
    }

    public enum MissingFieldOptions
    {
        /// <summary>
        /// Call error action with appropriate error action
        /// </summary>
        Throw,
        /// <summary>
        /// Return the additional values regardless.
        /// </summary>
        Return,
        /// <summary>
        /// Proceed to the next record without returning
        /// </summary>
        DiscardRecord,

        /// <summary>
        /// Return the record but with trailing empty fields (may be empty string or null)
        /// </summary>
        EmptyField,
    }

    public enum ErrorCode
    {
        /// <summary>
        /// Passed to the error action when MissingValueOptions.Throw is used
        /// </summary>
        MissingValues,
        /// <summary>
        /// Passed to the error action when MissingValueOptions.Throw is used
        /// </summary>
        ExtraValues,
        /// <summary>
        /// A special case used when no headers are available (which give the presumed arity of records)
        /// and the first two records in a file have differing number of values.
        /// </summary>
        VaryingValues
    }

    public record CsvConfig
    {
        /// <summary>
        /// True if the CSV file has headers, else false.
        /// </summary>
        public bool HasHeader { get; init; }

        /// <summary>
        /// The character which separates records.
        /// TODO: should this be a string?
        /// </summary>
        public char? RecordDelimiter { get; init; } = '\n';

        /// <summary>
        /// The character which separates fields within a record.
        /// TODO: should this be a string?
        /// </summary>
        public char? FieldDelimiter { get; init; } = ',';

        /// <summary>
        /// Character to enter quoted field.
        /// TODO: should this be restricted to "/'/`?
        /// </summary>
        public char? Quote { get; init; } = '"';

        /// <summary>
        /// Char which escapes quotes inside a quoted field.
        /// Set to null to prevent delimiting inside quotes.
        /// </summary>
        public char? EscapeCharInQuotes { get; init; } = '"';

        /// <summary>
        /// Char which escapes special chars outside the quotes of a field.
        /// Set to null to prevent delimiting in this way.
        /// </summary>
        public char? EscapeCharOutQuotes { get; init; } = '\\';

        /// <summary>
        /// If a record starts with this character, skip it until the next record delimiter.
        /// </summary>
        public char? CommentChar { get; init; } = '#';

        // public bool InLineComments

        /// <summary>
        /// 
        /// </summary>
        public TrimmingOptions Trimming { get; init; } = TrimmingOptions.None;

        /// <summary>
        /// Retain quotes around a field, after applying trimming options.
        /// </summary>
        public bool RetainQuotes { get; init; } = false;

        // Record ends with delimiter is a good reason to make record delimiter etc. strings

        /// <summary>
        /// What to do if a record has extra values.
        /// </summary>
        public ExtraFieldOptions ExtraFieldAction { get; init; }

        /// <summary>
        /// What to do if a record has missing values.
        /// </summary>
        public MissingFieldException MissingFieldAction { get; init; }


        public bool SkipEmptyLines { get; init; }

        public bool EmptyFieldAsNull { get; init; }

        // Potentially want to allow skip header, null if (should be client side really)
    }
}
