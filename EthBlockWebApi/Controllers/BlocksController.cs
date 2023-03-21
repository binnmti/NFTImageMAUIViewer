using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Shared;
using EthBlockWebApi.Data;

namespace EthBlockWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlocksController : ControllerBase
{
    private readonly EthBlockWebApiContext _context;

    public BlocksController(EthBlockWebApiContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetBlock")]
    public IEnumerable<Block> Get()
        => _context.Block;


    //// GET: Blocks
    //public async Task<IActionResult> Index()
    //{
    //      return _context.Block != null ? 
    //                  View(await _context.Block.ToListAsync()) :
    //                  Problem("Entity set 'EthBlockWebApiContext.Block'  is null.");
    //}

    //// GET: Blocks/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null || _context.Block == null)
    //    {
    //        return NotFound();
    //    }

    //    var block = await _context.Block
    //        .FirstOrDefaultAsync(m => m.BlockId == id);
    //    if (block == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(block);
    //}

    //// GET: Blocks/Create
    //public IActionResult Create()
    //{
    //    return View();
    //}

    //// POST: Blocks/Create
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("BlockId,Number,BlockHash,Author,SealFields,ParentHash,Nonce,Sha3Uncles,LogsBloom,TransactionsRoot,StateRoot,ReceiptsRoot,Miner,Difficulty,TotalDifficulty,MixHash,ExtraData,Size,GasLimit,GasUsed,Timestamp,Uncles,BaseFeePerGas")] Block block)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(block);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(block);
    //}

    //// GET: Blocks/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null || _context.Block == null)
    //    {
    //        return NotFound();
    //    }

    //    var block = await _context.Block.FindAsync(id);
    //    if (block == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(block);
    //}

    //// POST: Blocks/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, [Bind("BlockId,Number,BlockHash,Author,SealFields,ParentHash,Nonce,Sha3Uncles,LogsBloom,TransactionsRoot,StateRoot,ReceiptsRoot,Miner,Difficulty,TotalDifficulty,MixHash,ExtraData,Size,GasLimit,GasUsed,Timestamp,Uncles,BaseFeePerGas")] Block block)
    //{
    //    if (id != block.BlockId)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            _context.Update(block);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!BlockExists(block.BlockId))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(block);
    //}

    //// GET: Blocks/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null || _context.Block == null)
    //    {
    //        return NotFound();
    //    }

    //    var block = await _context.Block
    //        .FirstOrDefaultAsync(m => m.BlockId == id);
    //    if (block == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(block);
    //}

    //// POST: Blocks/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    if (_context.Block == null)
    //    {
    //        return Problem("Entity set 'EthBlockWebApiContext.Block'  is null.");
    //    }
    //    var block = await _context.Block.FindAsync(id);
    //    if (block != null)
    //    {
    //        _context.Block.Remove(block);
    //    }
        
    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    //private bool BlockExists(int id)
    //{
    //  return (_context.Block?.Any(e => e.BlockId == id)).GetValueOrDefault();
    //}
}
